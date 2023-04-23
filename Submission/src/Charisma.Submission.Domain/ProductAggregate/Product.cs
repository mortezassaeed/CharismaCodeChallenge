using Charisma.Framework.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charisma.Submission.Domain.ProductAggregate;

public class Product : AggregateRoot<int>
{
    public string ProductCode { get; set; }
    public ProductType Type { get; set; }
}

