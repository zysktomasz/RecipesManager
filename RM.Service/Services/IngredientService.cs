using RM.Repo;
using RM.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RM.Service.Services
{
    public class IngredientService : IIngredientService
    {
        private readonly IUnitOfWork _unitOfWork;

        public IngredientService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
