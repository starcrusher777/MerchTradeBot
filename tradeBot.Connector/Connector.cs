namespace tradeBot.Connector;

public class Connector
{
    private List<(string, string)> _authHeaders;

    public Connector(List<(string, string)> authHeaders)
    {
        _authHeaders = authHeaders;
        API = new ApiClients(_authHeaders);
    }

    public ApiClients API;
}