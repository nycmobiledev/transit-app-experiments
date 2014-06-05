using System;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Wmt
{
    public class App
    {
        public static Page GetMainPage()
        {	
            return  new NavigationPage(new StationsPage());
        }


    }
}

