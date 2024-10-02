using ECommerceWebsite.DTOs.CategoryDto;
using ECommerceWebsite.DTOs.OrderDetailsDto;
using ECommerceWebsite.Models;

namespace ECommerceWebsite.Mappers
{
    public static class CategoryMapper
    {
        public static CategoryDto ToCategoryDto(this Category categoryModel)
        {
            return new CategoryDto
            {

                CategoryId = categoryModel.CategoryId,
                Name = categoryModel.Name,
                Description = categoryModel.Description,

            };
        }

        public static Category FromCreatedToCategoryDto(this CreateCategoryDto categoryDto)
        {
            return new Category
            {
                Name = categoryDto.Name,
                Description = categoryDto.Description,
            };
        }

    }
}
