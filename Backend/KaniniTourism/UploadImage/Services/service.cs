using UploadImage.Interfaces;
using UploadImage.Models;

namespace UploadImage.Services
{
    class service : IService
    {
        public void GetPic()
        {
            using var dbContext = new Context();

            Console.WriteLine("1. Upload Image");
            Console.WriteLine("2. Retrieve Image");
            Console.Write("Choose an option: ");
            int option = int.Parse(Console.ReadLine());

            if (option == 1)
            {
                Console.Write("Enter path to image file: ");
                string imagePath = Console.ReadLine();

                byte[] imageData = File.ReadAllBytes(imagePath);

                var image = new Image
                {
                    Id = 1, // Set your desired ID
                    ImageData = imageData
                };

                dbContext.Images.Add(image);
                dbContext.SaveChanges();

                Console.WriteLine("Image uploaded successfully.");
            }
            else if (option == 2)
            {
                Console.Write("Enter image ID to retrieve: ");
                int imageId = int.Parse(Console.ReadLine());

                var image = dbContext.Images.FirstOrDefault(i => i.Id == imageId);

                if (image != null)
                {
                    File.WriteAllBytes($"retrieved_image_{image.Id}.jpg", image.ImageData);
                    Console.WriteLine("Image retrieved successfully.");
                }
                else
                {
                    Console.WriteLine("Image not found.");
                }
            }
        }
    }
}
