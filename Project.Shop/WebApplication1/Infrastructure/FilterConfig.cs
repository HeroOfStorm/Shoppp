using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IdentityExample.Infrastructure
{
    //создаем пользовательский класс для регистрации фильтров (это для удобства, т.к. данный код можно 
    //было прописать сразу же в файле global.asax
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filter)
        {

            //Если включен данный фильтр, то все контроллеры доступны только
            //авторизованным пользователям
       //     filter.Add(new AuthorizeAttribute());
            filter.Add(new HandleErrorAttribute());
        }
    }
}