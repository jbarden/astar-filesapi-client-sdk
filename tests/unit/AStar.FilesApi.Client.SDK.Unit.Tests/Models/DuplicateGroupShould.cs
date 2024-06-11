using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStar.FilesApi.Client.SDK.Models;

public class DuplicateGroupShould
{
    [Fact]
    public void ReturnTheExpectedToString()
        => new DuplicateGroup().ToString().Should().Be(@"{""Group"":{""FileLength"":0,""Height"":0,""Width"":0,""FileSizeForDisplay"":""0.00 Kb""},""Files"":[]}");
}
