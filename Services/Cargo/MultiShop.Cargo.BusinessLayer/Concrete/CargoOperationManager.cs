using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.BusinessLayer.Concrete
{
    public class CargoOperationManager : ICargoOperationService
    {
        private readonly ICargoOperationDal _cargoOperationDal;

        public CargoOperationManager(ICargoOperationDal cargoOperationDal)
        {
            _cargoOperationDal = cargoOperationDal;
        }

        public async Task TCreateAsync(CargoOperation entity)
        {
            await _cargoOperationDal.CreateAsync(entity);
        }

        public async Task<List<CargoOperation>> TGetAllAsync()
        {
            return await _cargoOperationDal.GetAllAsync();
        }

        public async Task<CargoOperation> TGetByIdAsync(int id)
        {
            return await _cargoOperationDal.GetByIdAsync(id);
        }

        public async Task TRemoveAsync(int id)
        {
            await _cargoOperationDal.RemoveAsync(id);
        }

        public async Task TUpdateAsync(CargoOperation entity)
        {
           await _cargoOperationDal.UpdateAsync(entity);
        }
    }
}
