using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Domain.Entities
{
    public class Stock
    {
        #region Properties

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }

        #endregion

        #region Navigations

        public virtual List<Product> Products { get; set; }

        #endregion
    }
}
