namespace MVC_E_Learning.Utility
{
    public class DocumentSettings
    {
        public static string UploadFile(IFormFile file, string folderName)
        {
            var folderpath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Files", folderName);

            var filename = $"{Guid.NewGuid()}-{file.FileName}";

            var filepath = Path.Combine(folderpath, filename);

            using (var filestream = new FileStream(filepath, FileMode.Create))
            {
                file.CopyTo(filestream);

            }
            return filename;
        }

        public static void DeleteFile(string fileName, string folderName)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Files", folderName, fileName);

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
    }
}
