/**
 * Copyright (C) 2017 Kamarudin (http://coding4ever.net/)
 *
 * Licensed under the Apache License, Version 2.0 (the "License"); you may not
 * use this file except in compliance with the License. You may obtain a copy of
 * the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS, WITHOUT
 * WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the
 * License for the specific language governing permissions and limitations under
 * the License.
 *
 * The latest version of this file can be found at https://github.com/rudi-krsoftware/open-retail
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using log4net;
using OpenRetail.Model;
using OpenRetail.Bll.Api;
using OpenRetail.Repository.Api;
using OpenRetail.Repository.Service;
 
namespace OpenRetail.Bll.Service
{    
    public class HeaderNotaMiniPosBll : IHeaderNotaMiniPosBll
    {
		private ILog _log;
        private IUnitOfWork _unitOfWork;
		private HeaderNotaMiniPosValidator _validator;

		public HeaderNotaMiniPosBll()
        {
            _validator = new HeaderNotaMiniPosValidator();
        }

        public IList<HeaderNotaMiniPos> GetAll()
        {
            IList<HeaderNotaMiniPos> oList = null;

            using (IDapperContext context = new DapperContext())
            {
                _unitOfWork = new UnitOfWork(context, _log);
                oList = _unitOfWork.HeaderNotaMiniPosRepository.GetAll();
            }

            return oList;
        }

		public int Save(HeaderNotaMiniPos obj)
        {
            throw new NotImplementedException();
        }

		public int Update(HeaderNotaMiniPos obj)
        {
            var result = 0;

            using (IDapperContext context = new DapperContext())
            {
                _unitOfWork = new UnitOfWork(context, _log);
                result = _unitOfWork.HeaderNotaMiniPosRepository.Update(obj);
            }

            return result;
        }

        public int Update(HeaderNotaMiniPos obj, ref ValidationError validationError)
        {
            var validatorResults = _validator.Validate(obj);

            if (!validatorResults.IsValid)
            {
                foreach (var failure in validatorResults.Errors)
                {
                    validationError.Message = failure.ErrorMessage;
                    validationError.PropertyName = failure.PropertyName;
                    return 0;
                }
            }

            return Update(obj);
        }

        public int Delete(HeaderNotaMiniPos obj)
        {
            throw new NotImplementedException();
        }
    }
}     
