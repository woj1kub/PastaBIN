﻿using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public interface IPastaImg
    {
        //Dla past img
        public string AddImgPasta(int? CookID,PastaImageRequest pastaImageRequest);
        public IEnumerable<PastaImageResponse> GetPastaImgByUser(int CookID);
        public IEnumerable<PastaImageResponse> GetPastaImgByUserFromPastaSharing(int CookID);
        public Task<Stream> GetPastaImgByKey(string key, int CookID);
        public Task<Stream> GetPastaImgByBindID(int BindID);

    }
}
