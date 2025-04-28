using Microsoft.SemanticKernel;
using ModelContextProtocol.Client;
using ModelContextProtocol.Protocol.Transport;

public class PuppeteerPlugin : IAsyncDisposable
{
    private readonly IMcpClient _mcpClient;

    public PuppeteerPlugin(IMcpClient mcpClient)
    {
        _mcpClient = mcpClient;
    }

    public static async Task<PuppeteerPlugin> CreateAsync()
    {
        var mcpClient = await McpClientFactory.CreateAsync(new StdioClientTransport(new()
        {
            Name = "puppeteer",
            Command = "npx",
            Arguments = ["-y", "@modelcontextprotocol/server-puppeteer"],
        }));
        return new PuppeteerPlugin(mcpClient);
    }

    [KernelFunction("list_tools")]
    public async Task<IList<McpClientTool>> ListToolsAsync()
    {
        return await _mcpClient.ListToolsAsync().ConfigureAwait(false);
    }

    public async ValueTask DisposeAsync()
    {
        await _mcpClient.DisposeAsync();
    }
}