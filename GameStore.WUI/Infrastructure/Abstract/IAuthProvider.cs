﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.WUI.Infrastructure.Abstract
{
   public interface IAuthProvider
    {
        bool Authenticate(string username, string password);
    }
}
