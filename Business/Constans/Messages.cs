using Core.Entities.Concrete;
using Entities.Concrete;
using Newtonsoft.Json;

namespace Business.Constans
{
    public static class Messages
    {
        public static string SuccessAdded = JsonConvert.SerializeObject("Alan başarıyla eklendi");
        public static string SuccessUpdated = JsonConvert.SerializeObject("Alan başarıyla güncellendi");
        public static string SuccessDeleted = JsonConvert.SerializeObject("Alan başarıyla silindi");
        public static string SuccessTerminate = JsonConvert.SerializeObject("Alan kalıcı olarak başarıyla silindi.");
        public static string SuccessListed = JsonConvert.SerializeObject("İstenen bilgiler başarıyla listelendi");
        public static string FieldAlreadyExist = JsonConvert.SerializeObject("Bu alan daha önce eklenmiş");
        public static string AuthorizationDenied = JsonConvert.SerializeObject("Bu işlemi yapmak için yetkiniz bulunmamaktadır");
        public static string UserRegistered = JsonConvert.SerializeObject("Başarıyla kayıt oldunuz");
        public static string UserNotFound = JsonConvert.SerializeObject("Kullanıcı bulunamadı");
        public static string UserAlreadyExists = JsonConvert.SerializeObject("Kullanıcı mevcut");
        public static string PasswordError = JsonConvert.SerializeObject("Parola hatası");
        public static string SuccessfulLogin = JsonConvert.SerializeObject("Giriş başarılı");
        public static string AccessTokenCreated = JsonConvert.SerializeObject("İşlem başarılı");
        public static string PasswordNotSame = JsonConvert.SerializeObject("Password alanları aynı değil");
        public static string SuccessPasswordChange= JsonConvert.SerializeObject("Password başarıyla değiştirildi");
        public static string PermissionError = JsonConvert.SerializeObject("You do not have permission to view this data. Please contact your administrator.");
        public static string PasswordExist = JsonConvert.SerializeObject("Şifre bir önceki şifre ile aynı olamaz.");
        public static string ImageNotFound = JsonConvert.SerializeObject("Resim bulunamdı.");
    }
}
