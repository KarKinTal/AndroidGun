using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndroidGunFinal.ViewModels
{
    public partial class WydanieViewModel: BaseViewModel
    {
        [ObservableProperty]
        private string _code;
    }
}
