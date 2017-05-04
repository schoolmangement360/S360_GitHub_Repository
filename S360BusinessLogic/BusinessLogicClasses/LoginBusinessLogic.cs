﻿using S360Entity;
using S360Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S360BusinessLogic
{
    public class LoginBusinessLogic
    {
        private UserCredentialRepository _userCredentialRepository;
        private UserLoginDetailRepository _userLoginDetailRepository;

        public LoginBusinessLogic()
        {
            _userCredentialRepository = S360RepositoryFactory.GetRepository("USERCREDENTIAL") as UserCredentialRepository;
            _userLoginDetailRepository = S360RepositoryFactory.GetRepository("USERLOGINDETAIL") as UserLoginDetailRepository;
        }

        public LoginModel LoginAccess(LoginModel loginDetails)
        {
            LoginModel loginModel = new LoginModel();

            if (loginDetails != null)
            {
                if (string.IsNullOrEmpty(loginDetails.Username) && string.IsNullOrWhiteSpace(loginDetails.Username))
                {
                    loginModel.Message = "Invalid User Name";
                    loginModel.IsLogin = false;
                    return loginModel;
                }

                if (string.IsNullOrEmpty(loginDetails.Password) && string.IsNullOrWhiteSpace(loginDetails.Password))
                {
                    loginModel.Message = "Invalid Password";
                    loginModel.IsLogin = false;
                    return loginModel;
                }

                var login = _userCredentialRepository.GetAll().Where(l => l.Username.ToUpper() == loginDetails.Username.ToUpper() && l.Password == loginDetails.Password);
                if (login != null && login.Count() != 0)
                {
                    loginModel.Message = "Login Sucess";
                    loginModel.IsLogin = true;
                    loginModel.UserID = login.FirstOrDefault().User_ID;
                    GEN_UserLogin_Details result = this.MarkLogin(login.FirstOrDefault().User_ID);
                    loginModel.LoginID = result.Login_ID;
                }
                else
                {
                    loginModel.Message = "Invalid User Credential";
                    loginModel.IsLogin = false;
                }

            }
            else
            {
                loginModel.IsLogin = false;
                return loginModel;
            }

            return loginModel;
        }

        public GEN_UserLogin_Details MarkLogin(decimal userID)
        {
            GEN_UserLogin_Details userlogindetail = new GEN_UserLogin_Details();
            userlogindetail.User_ID = userID;
            userlogindetail.LoginTime = DateTime.Now;
            return _userLoginDetailRepository.Insert(userlogindetail);
        }

        public void MarkLogout(decimal loginID)
        {
            GEN_UserLogin_Details userlogindetail = _userLoginDetailRepository.GetAll().Where(l => l.Login_ID == loginID).FirstOrDefault();
            userlogindetail.LogoutTime = DateTime.Now;
            _userLoginDetailRepository.Update(userlogindetail);
        }

        public void ActivateApplication()
        {
            var activate = _userCredentialRepository.GetAll();
        }

    }
}