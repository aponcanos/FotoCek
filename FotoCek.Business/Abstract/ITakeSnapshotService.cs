﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FotoCek.Entities.DbClasses;

namespace FotoCek.Business.Abstract
{
    public interface ITakeSnapshotService
    {
        byte[] TakeSnapshot(Camera camera, DateTime eventDate);
    }
}