using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class DateTimeExtensionsTest
{
    [Test]
    public void ChangeDateTest()
    {
        var today = DateTime.Now.Date;
        var yesterday = today.AddDays(-1);
        today = today.ChangeDate(yesterday.Year, yesterday.Month, yesterday.Day);
        Assert.AreEqual(yesterday, today);
    }
    [Test]
    public void ChangeTimeTest()
    {
        var today = DateTime.Now.Date;
        var afterAnHour = today.AddHours(1);
        afterAnHour = afterAnHour.ChangeTime(today.Hour,today.Minute,today.Second,today.Millisecond); 
        Assert.AreEqual(afterAnHour, today);
    }
}
