using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class LoginResult: ICommand {
    public int roleIndex;
    public LOGIN_RETURN_CODE returnCode;
}
