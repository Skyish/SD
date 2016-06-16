using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CentralService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class CentralService : ICentralService
    {
        public string Register(Theme theme, string language)
        {
            Console.WriteLine(theme.theme);
            Console.WriteLine(language);

            return "Gotcha! " + theme.theme + " || " + language;
        }

        public void UnRegister(Theme theme)
        {
            throw new NotImplementedException();
        }
    }
}
