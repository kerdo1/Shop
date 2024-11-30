using ShopTARge23.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopTARge23.Core.ServiceInterface;
using ShopTARge23.Core.Domain;
using Microsoft.EntityFrameworkCore;
using ShopTARge23.Core.Dto;

namespace ShopTARge23.ApplicationServices.Services
{
    public class RealEstatesServices : IRealEstateServices
    {
        private readonly ShopTARge23Context _context;
        private readonly IFileServices _fileServices;

        public RealEstatesServices
            (
                ShopTARge23Context context,
                IFileServices fileServices
            )
        {
            _context = context;
            _fileServices = fileServices;
        }


        public async Task<RealEstate> GetAsync(Guid id)
        {
            var result = await _context.RealEstates
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }

        public async Task<RealEstate> Create(RealEstateDto dto)
        {
            RealEstate realEstate = new RealEstate();

            realEstate.Id = Guid.NewGuid();
            realEstate.Location = dto.Location;
            realEstate.Size = dto.Size ?? 0.0; // Provide a default value if null
            realEstate.RoomNumber = dto.RoomNumber ?? 0;
            realEstate.BuildingType = dto.BuildingType;
            realEstate.CreatedAt = DateTime.Now;
            realEstate.ModifiedAt = DateTime.Now;

            if (dto.Files != null)
            {
                _fileServices.UploadFilesToDatabase(dto, realEstate);
            }

            await _context.RealEstates.AddAsync(realEstate);
            await _context.SaveChangesAsync();

            return realEstate;
        }


        public async Task<RealEstate> Update(RealEstateDto dto)
        {
            var domain = new RealEstate()
            {
                Id = dto.Id,
                Location = dto.Location,
                Size = dto.Size ?? 0.0,
                RoomNumber = dto.RoomNumber ?? 0,
                BuildingType = dto.BuildingType,
                CreatedAt = dto.CreatedAt ?? DateTime.Now,
                ModifiedAt = DateTime.Now,
            };

            if (dto.Files != null)
            {
                _fileServices.UploadFilesToDatabase(dto, domain);
            }

            _context.RealEstates.Update(domain);
            await _context.SaveChangesAsync();

            return domain;
        }

        public async Task<RealEstate> Delete(Guid id)
        {
            var result = await _context.RealEstates
                .FirstOrDefaultAsync(x => x.Id == id);

            var images = await _context.FileToDatabases
                .Where(x => x.RealEstateId == id)
                .Select(y => new FileToDatabaseDto
                {
                    Id = y.Id,
                    ImageTitle = y.ImageTitle,
                    RealEstateId = y.RealEstateId
                }).ToArrayAsync();

            await _fileServices.RemoveImagesFromDatabase(images);
            _context.RealEstates.Remove(result);
            await _context.SaveChangesAsync();

            return result;
        }
    }
}
