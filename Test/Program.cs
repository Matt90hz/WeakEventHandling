using BenchmarkDotNet.Running;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using BenchmarkDotNet.Diagnosers;
using System.Diagnostics;

#if DEBUG
HostConfiguration.CreateHost().Services.GetRequiredService<Test>().Run();
#else
BenchmarkRunner.Run<Benchmark>();
#endif




