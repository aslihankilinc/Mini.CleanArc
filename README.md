***Amaç***
Bu proje, **görev (task)** ve **kullanıcı (user)** yönetimi için
örnek bir backend uygulamasıdır.  
Kod yapısı Clean Architecture standartlarına göre düzenlendi
böylece her katmanın sorumluluğu net bir şekilde ayrıldı.

***Kullanım Adımı***
Uygulama ilk kez migration çalıştırdığında,  
`Infrastructure/Persistence/SeedData` altındaki 
JSON dosyalarından (örnek: `users.json`, `tasks.json`) başlangıç verilerini yükler.
Veritabanı yerini .appsetting'ten değiştir.

****Mimari Yapı****

src/

``` ├── Core/ → Domain ve Application katmanı```

```│ ├──``` Domain/ → Entity’ler, Value Object’ler

```│ └──``` Application/ → Use Case’ler, Interface’ler, DTO’lar

```│ ├──``` Contracts/ → IService Interface’leri (IUserService, ITaskService)

```│ ├──``` Models/ → DTO’lar (Create, Update, Response)

```│ └──``` Validators/ → FluentValidation sınıfları

```├── Infrastructure/ → Veritabanı ve servis implementasyonları```

```│ ├──``` Data/ → AppDbContext, SeedData

```│ ├──``` Migrations/ → EF Core migration dosyaları

```│ ├──``` Extensions/ → Migration & ServiceRegistration extension’ları

```│ ├──```Services/ → UserService, TaskService implementasyonları

```│ └── ```MapperConfig.cs → AutoMapper yapılandırması

```└── WebAPI/ → API katmanı```

```├── ```Controllers/ → UsersController, TasksController

```├──``` Middleware/ → Hata yönetimi (ErrorHandlingMiddleware)

```├── ```appsettings.json → Connection string ayarları

```└── ```Program.cs → Dependency Injection ve pipeline tanımı

tests/

```├──``` UnitTests/ → InMemory EF Core ile servis testleri
