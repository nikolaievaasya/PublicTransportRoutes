using Microsoft.Extensions.DependencyInjection;
using PublicTransportRoutes.Services;
using PublicTransportRoutes.View;
using PublicTransportRoutes.ViewModel;
using System;
using System.Windows;

namespace PublicTransportRoutes
{
    public partial class App : Application
    {
        private ServiceProvider _serviceProvider;

        App()
        {
            //  Создаёться колекция для хранения сервисов и зависимостей
            IServiceCollection services = new ServiceCollection();

            ///  Добавляем DataStorageService
            ///  Этот сервис будет служить общим вместилищем для хранения данных.
            ///  К примеру, у нас на двух странциах есть использванье колекции DriverCollection.
            ///  На странице AddDriverView у нас происходит добавление новых обьектов и сериализация колекции,
            ///  а на странице AddTransportView у нас есть ComboBox, элементы которого это имена водителей из DriverCollection.
            ///  И как раз для того, чтобы со всех ViewModel был доступ к одной единственной колекции, 
            ///  и при изменении этой колекции происходило обновление данных везде где необходимо, необходимо сделать этот сервис.

            services.AddSingleton<IDataStorageService, DataStorageService>();

            /// Добавляем главное окно в список сервисов.
            /// Указываем что DataContext'ом этого окна будет MainWindowViewModel, для реализации MVVM паттерна.
            /// MainWindowViewModel берём из провайдера с помощью лямбда выражения и метода GetRequiredService.


            services.AddSingleton(provider => new MainWindow
            {
                DataContext = provider.GetRequiredService<MainWindowViewModel>()
            });
            
            /// Добавление новых ViewModel
            /// Чтобы добавить новые ViewModel нужно использовать метод AddSingleton.
            /// В типе метода нужно указать добавляемый класс ViewModel.

            services.AddSingleton<MainWindowViewModel>();
            services.AddSingleton<HomeViewModel>();

            services.AddSingleton<AddViewModel>();

            services.AddSingleton<AddDriverViewModel>();
            services.AddSingleton<AddTransportViewModel>();
            services.AddSingleton<AddBusStopViewModel>();
            services.AddSingleton<AddRouteViewModel>();
            services.AddSingleton<AddRoutePointViewModel>();
            services.AddSingleton<AddTransportRouteViewModel>();

            services.AddSingleton<SearchViewModel>();

            services.AddSingleton<SearchDriverViewModel>();
            services.AddSingleton<SearchDriverByFullNameViewModel>();
            services.AddSingleton<SearchDriverByPhoneViewModel>();

            services.AddSingleton<SearchTransportViewModel>();
            services.AddSingleton<SearchTransportByDriverViewModel>();
            services.AddSingleton<SearchTransportByTransportNumberViewModel>();

            services.AddSingleton<SearchRouteViewModel>();

            services.AddSingleton<SearchBusStopRoutesViewModel>();


            //  Добавление NavigationService для переключения View в окне.
            services.AddSingleton<INavigationService, NavigationService>();

            //Этот кусок кода я вообще не выкупаю как работает... Потом разберусь
            services.AddSingleton<Func<Type, Core.ViewModel>>(provider => viewModelType => (Core.ViewModel)provider.GetRequiredService(viewModelType));

            //  После всех добавлений вызываем BuildServiceProvider.
            _serviceProvider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            //  Получаем главное окно из провайдера.
            var mainVindow = _serviceProvider.GetRequiredService<MainWindow>();

            //Показываем наше окно.
            mainVindow.Show();

            base.OnStartup(e);
        }
    }
}
