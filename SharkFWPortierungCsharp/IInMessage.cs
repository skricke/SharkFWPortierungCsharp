﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shark.ASIP {
  public interface IInMessage : IMessage {
    new IInMessageContent Content { get; }
  }
}
