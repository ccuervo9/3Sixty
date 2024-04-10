using DataAccess.Interfaces.Payment;
using System.Collections.Generic;
using BussinesLogic.Services.PaymentDTO;

namespace Service.Services.Payment
{
    public class PaymentService : IPaymentRepository
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<PaymentDTO> GetAllProducts() => _productRepository.GetAll();

        public PaymentDTO GetProductById(int id) => _productRepository.GetById(id);

        public void AddProduct(PaymentDTO product) => _productRepository.Add(product);

        public void UpdateProduct(PaymentDTO product) => _productRepository.Update(product);

        public void DeleteProduct(int id) => _productRepository.Delete(id);
    }  
}
