﻿namespace Application.Models
{
    public class GetPropertyByIdResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<GetImageByIdResponse> Images { get; set; }
    }
}
