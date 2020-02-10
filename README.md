# DynamicConfiguration

Dynamic configuration structure.
The purpose of the project is that appkey in web.config, app.config files held in a common and dynamic structure be accessible, without requiring deployment or restart.


DynamicConfigurator.ConfigurationReader
ConfigurationReader sınıfı HostedService sınıfından türetilerek belirlenen sürede storagedan datayı çekerken normal hizmetine de devam etmesi sağlanmıştır.

Kullanmak istediğiniz projede aşağıdaki satırı Startup içerisindeki ConfigureServices methodunun içinde çağırın.
services.AddSingleton(s => new ConfigurationReader("applicationName", "connecttionString", 30000));

Parametreye ihtiyaç duyulan yerde aşağıdaki şekilde ulaşılabilir.
_configurationReader.GetValue<string>("SiteName");
