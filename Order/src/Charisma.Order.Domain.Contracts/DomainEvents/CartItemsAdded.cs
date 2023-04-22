﻿using Charisma.Framework.Domain.DomainEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charisma.Order.Domain.Contracts.DomainEvents;

public record CartItemsAdded(int CustomerId, List<string> ProductCode) : DomainEvent;
