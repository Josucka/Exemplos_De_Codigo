using OpenTelemetry;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using System.Diagnostics;

class Program
{
    private static ActivitySource _source = new ActivitySource("DemoTelemetria.TelemetriaWithCSharp", "1.0.0");
    static async Task Main(string[] args)
    {
        using var tracerProvider = Sdk.CreateTracerProviderBuilder()
            .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("TelemetriaWithCSharp"))
            .AddSource("DemoTelemetria.TelemetriaWithCSharp")
            .AddConsoleExporter().Build();

        await DoSomeWork("banana", 8);
        await DoSomeWork("Carro", 15);
        Console.WriteLine("Example work done");
    }

    private static async Task DoSomeWork(string foo, int bar)
    {
        using(Activity activity = _source.StartActivity("SomeWork"))
        {
            if(activity != null)
            {
                activity.SetTag("foo", foo);
                activity.SetTag("bar", bar);
            }//o if ou linha 30/31
            //activity?.SetTag("foo", foo);
            //activity?.SetTag("bar", bar);
            await StepOne();
            activity?.AddEvent(new ActivityEvent("Part way there"));
            await StepTwo();
            activity?.AddEvent(new ActivityEvent("Done now"));

            //Pretend somthing went wrong
            activity?.SetTag("otel.status_code", "ERROR");
            activity?.SetTag("otel.status_description", "Use this text give more information about the error");
        }
    }

    private static async Task StepTwo()
    {
        using(Activity activity = _source.StartActivity("StepOne"))
        {
            await Task.Delay(500);
        }
    }

    private static async Task StepOne()
    {
        using(Activity activity = _source.StartActivity("StepTwo"))
        {
            await Task.Delay(1000);
        }
    }
}