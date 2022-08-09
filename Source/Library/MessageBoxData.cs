﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library
{
    public class MessageBoxData
    {
        public object[][] messageData = new object[][]
        {
            new object[]
            {
                "Error!",
                "The provided path is invalid! Change it and try again",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            },

            new object[]
            {
                "Success!",
                "Operation Complete! Skiped entries: ",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation
            },
        };
    }
}
