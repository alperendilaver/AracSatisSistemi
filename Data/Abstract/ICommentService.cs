using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using yazilim_mimari.Models.Yorum;

namespace yazilim_mimari.Data.Abstract
{
    public interface ICommentService
    {
        public Task<int> YorumEkle(YorumEkleViewModel yorumEkleViewModel); 
    }
}