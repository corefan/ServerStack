﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ServerStack.Serialization
{
    public interface IFrameEncoder<TOutput>
    {
        Task Encode(Stream output, TOutput value);
    }

}
