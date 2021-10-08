/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:Lab_UCP"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Lab_UCP.ViewModel.MainVM;
using LabUCP.ViewModel;

namespace Lab_UCP.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<LoginPageViewModel>();
            SimpleIoc.Default.Register<LoginWindowViewModel>();
            SimpleIoc.Default.Register<CheckWindowViewModel>();
            SimpleIoc.Default.Register<MenuListViewModel>();
            SimpleIoc.Default.Register<ScreenSaverViewModel>();
            SimpleIoc.Default.Register<ViewPageViewModel>();
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }
        public LoginPageViewModel LoginPage
        {
            get
            {
                return ServiceLocator.Current.GetInstance<LoginPageViewModel>();
            }
        }
        public LoginWindowViewModel LoginWindow
        {
            get
            {
                return ServiceLocator.Current.GetInstance<LoginWindowViewModel>();
            }
        }
        public CheckWindowViewModel Check
        {
            get
            {
                return ServiceLocator.Current.GetInstance<CheckWindowViewModel>();
            }
        }
        public MenuListViewModel MenuList
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MenuListViewModel>();
            }
        }
        public ScreenSaverViewModel ScreenSaver
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ScreenSaverViewModel>();
            }
        }
        public ViewPageViewModel pp
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ViewPageViewModel>();
            }
        }
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}