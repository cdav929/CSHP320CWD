using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace HomeInventoryApp
{
    
    public partial class App : Application
    {
        private static HomeInventoryRepository.HomeInventoryRepository homeInventoryRepository;

        static App()
        {
            homeInventoryRepository = new HomeInventoryRepository.HomeInventoryRepository();
        }

        public static HomeInventoryRepository.HomeInventoryRepository HomeInventoryRepository
        {
            get
            {
                return homeInventoryRepository;
            }
        }

    }
}
