using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SecureData.Data;
using SecureData.Interface;
using SecureData.Models;
using SecureData.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SecureData.BLL
{
    public class OrderProcessing    
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IConfiguration _configruation;
        public OrderProcessing (UnitOfWork unitOfWork, IConfiguration configruation)
        {
            _unitOfWork = unitOfWork;
            _configruation = configruation;
        }
        public bool saveDataToContext(IEnumerable<Order> entities)
        {
            if (_unitOfWork.OrderRepository.AddRange(entities) > 0)
            {
                _unitOfWork.Save();
                return true;
            }
            return false;
        }
        
        public bool saveDataToFile(List<Order> orders)
        {
            try
            {
                string fileName = _configruation.GetValue<string>(key: "OutputFiles:Orders");
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(Directory.GetCurrentDirectory(), fileName)))
                {
                    foreach (var order in orders)
                        if(order.paid)
                            outputFile.WriteLine(order.number);
                }
                return true;
            } catch
            {
                return false;
            }
        }
    }
}
