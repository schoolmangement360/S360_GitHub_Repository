using S360Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace S360BusinessLogic
{
    public class ChequeBusinessLogic
    {
        #region [ Private Variables ]

        private ChequeMasterRepository _chequeMasterRepository;
        private ChequeMasterTempRepository _chequeMasterTempRepository;

        #endregion

        #region [ Constructor ]

        public ChequeBusinessLogic()
        {
            _chequeMasterRepository = S360RepositoryFactory.GetRepository("CHEQUEMASTER") as ChequeMasterRepository;
            _chequeMasterTempRepository = S360RepositoryFactory.GetRepository("CHEQUEMASTERTEMP") as ChequeMasterTempRepository;
        }

        #endregion

        #region [ Public Methods ]

        /// <summary>
        /// insert cheque details into table
        /// </summary>
        /// <param name="Cheque"></param>
        public void SaveCheque(CHQ_Cheques_Master Cheque)
        {
            _chequeMasterRepository.Insert(Cheque);
        }

        /// <summary>
        /// Update cheque details in table
        /// </summary>
        /// <param name="Cheque"></param>
        public void UpdateCheque(CHQ_Cheques_Master Cheque)
        {
            _chequeMasterRepository.Update(Cheque);
        }

        /// <summary>
        /// get all cheques details from table
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CHQ_Cheques_Master> GetAllCheques()
        {
            return _chequeMasterRepository.GetAll();
        }

        /// <summary>
        /// Get all cheques details which are saved temporary
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CHQ_Cheques_Master_Temp> GetAllUnsavedCheques()
        {
            return _chequeMasterTempRepository.GetAll().Where(S => S.EnteredBy == S360Model.S360Configuration.Instance.UserID);
        }

        /// <summary>
        /// insert cheque in temp table
        /// </summary>
        /// <param name="Cheque"></param>
        public object SaveChequeTemp(CHQ_Cheques_Master_Temp Cheque)
        {
            Cheque = _chequeMasterTempRepository.Insert(Cheque);
            return Cheque;
        }

        /// <summary>
        /// Delete cheque from temp table
        /// </summary>
        /// <param name="Cheque"></param>
        public void DeleteTempCheque(CHQ_Cheques_Master_Temp Cheque)
        {
            _chequeMasterTempRepository.Delete(Cheque);
        }

        #endregion
    }
}
