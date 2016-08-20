using Rang_Out.Common;
using Rang_Out.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace Rang_Out.ViewModels
{
    public class LandingPageViewModel : BindableBase
    {

        private ObservableCollection<Seller> _sellers;

        public ObservableCollection<Seller> Sellers
        {
            get { return _sellers; }
            set { SetProperty( ref _sellers, value); }
        }



        public LandingPageViewModel()
        {
            Sellers = new ObservableCollection<Seller>()
            {
                new Seller()
                {
                    Name = "João das Neves",
                    LastPosX = -23.482941,
                    LastPosY = -46.500748
                },

                new Seller()
                {
                    Name = "Maria das Dores",
                    LastPosX = -25.482941,
                    LastPosY = -50.500748
                },

                new Seller()
                {
                    Name = "Faustão Silva",
                    LastPosX = -15.482941,
                    LastPosY = -40.500748
                },

                new Seller()
                {
                    Name = "Oswaldo Pires Xícara",
                    LastPosX = -30.482941,
                    LastPosY = -10.500748
                },

            };

            
        }
        

    }
}
