# Tag-Helper

### Released

Tag helpers, yeni bi özellik olarak ASP.NET Core 1.0 ile tanıtıldı.

## Nedir ve neden ihtiyaç duyuldu?

Tag Helpers, razor sayfalardaki server-side kodları HTML elementleri olarak oluşturmayı sağlar.

View’ın daha okunabilir, anlaşılabilir ve kolay geliştirilebilir hale gelmesine olanak tanır.

Html Helper kullanımlarının yerini almış yapılardır.

Web geliştiricilerinin, eski geleneksel HTML etiketlerini kullanmalarına yardımcı olur. Geliştiriciler, Tag Helpers yardımıyla HTML etiketini kullanarak 'view' katmanlarını tasarlayabilirken, sunucu tarafında C# ile iş mantığı kodlayabilirler.

Daha önceki sürümlerde kullanılmakta olan HTML Helper'lar, c# söz dizimiyle kullanıldığı için web sayfalarında ki kod okunabilirliği
azalıyordu. 

Tag helper'lar geleneksel html biçiminde kullanıldığı için daha temiz ve okunabilir kod düzeni sağlar.

```csharp
// HTML Helpers
@Html.ActionLink("Click", "Controller1", "CheckData", { @class="my-css-classname"}) 
```
```html
//Tag Helpers
<a asp-controller="Controller1" asp-action="CheckData" class="my-css-classname">Click</a>
```

# Built-in Tag Helpers

## Anchor Tag Helper
```html
<a asp-controller="Student" asp-action="Index" 
asp-route-id="@Model.Id"> StudentId: @Model.StudentId </a> >Student List</a>
```

## Cache Tag Helper
```html
 <cache enabled="true">
 Last Cached Time: @DateTime.Now
</cache>
```
## Distributed Cache Tag Helper
```html
 <distributed-cache name="unique-cache-1">
 Time Inside Cache Tag Helper: @DateTime.Now
</distributed-cache>
```
## Environment Tag Helper

```html
 <environment names="Testing,Release">
<strong>Application Environemt is Staging or Production</strong>
</environment>
```
## Form Tag Helper
```html
 <form asp-controller="Demo" asp-action="Save " method="post">
………………………………
</form>
```
## Input Tag Helper
```html
 @model Login
<form asp-controller="Demo" asp-action="Register" method="post">
Provide Email: <input asp-for="Email" /> 
Provide Password: <input asp-for="Password" />
<button type="submit">SignUp</button>
</form>
```
## Label Tag Helper
```html
 <form asp-controller="Demo" asp-action="Register" method="post">
<label asp-for="Email">Email Address</label>
<input asp-for="Email" /> 
</form>
```
## Select Tag Helper
```html
<select asp-for="Country" asp-items="Model.Countries"></select>
```
## Image Tag Helper
```html
<img src="~/images/asplogo.png" asp-append-version="true">
```

# Sources

https://learn.microsoft.com/en-us/aspnet/core/mvc/views/tag-helpers/built-in/?view=aspnetcore-7.0







