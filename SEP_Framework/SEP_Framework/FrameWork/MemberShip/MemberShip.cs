﻿using SEP_Framework.FrameWork.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEP_Framework.MemberShip
{
    public class Member
    {
        private AbstractController controller;

        public Member(AbstractController controller)
        {
            this.controller = controller;
            controller.createUserTable();
        }

        public bool Login(string username, string password)
        {
            if (controller.Login(username, password))
            {
                return true;
            }
            return false;
        }

        public bool Register(string username, string password)
        {
            if (controller.Register(username, password))
            {
                return true;
            }
            return false;
        }

        public bool Logout(string username)
        {
            if (controller.Logout(username))
            {
                return true;
            }
            return false;
        }
    }
}
