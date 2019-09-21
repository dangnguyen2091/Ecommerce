using Ecommerce.ViewModel;
using System;
using System.Collections.Generic;

namespace Ecommerce.Business.BUS
{
    public class Business<TEdit, TDisplay> where TEdit : BaseViewModel where TDisplay : BaseViewModel
    {
        protected readonly IUnitOfWork unitOfWork;

        public Business(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        protected virtual string Validate(TEdit viewModel) { return string.Empty; }

        protected List<TEntity> CastToEntities<TViewModel, TEntity>(List<TViewModel> viewModels)
            where TEntity : class where TViewModel : BaseViewModel
        {
            List<TEntity> entities = new List<TEntity>();
            foreach (TViewModel viewModel in viewModels)
            {
                TEntity entity = (TEntity)viewModel.ToEntity();
                entities.Add(entity);
            }
            return entities;
        }

        protected List<TViewModel> CastToViewModels<TEntity, TViewModel>(List<TEntity> entities)
            where TEntity : class where TViewModel : BaseViewModel
        {
            List<TViewModel> viewModels = new List<TViewModel>();
            foreach (TEntity entity in entities)
            {
                TViewModel viewModel = Activator.CreateInstance<TViewModel>();
                viewModel.BindEntity(entity);
                viewModels.Add(viewModel);
            }
            return viewModels;
        }

    }
}
