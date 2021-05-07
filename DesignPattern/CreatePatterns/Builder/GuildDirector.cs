namespace DesignPattern.CreatePatterns.Builder
{
    public class GuildDirector
    {
        private GuildBuilder _guildBuilder { get; set; }

        public GuildDirector(GuildBuilder guildBuilder)
        {
            this._guildBuilder = guildBuilder;
        }

        public Guild CreateAuditGuild(string Name)
        {
            this._guildBuilder.ReInitInstance();
            this._guildBuilder.BuildName(Name);
            this._guildBuilder.BuildJoinAudit(true);
            return _guildBuilder.GetInstance();
        }
        
        public Guild CreateNotAuditGuild(string Name)
        {
            this._guildBuilder.ReInitInstance();
            this._guildBuilder.BuildName(Name);
            this._guildBuilder.BuildJoinAudit(false);
            return _guildBuilder.GetInstance();
        }

        public Guild UpdateGuildToVip(Guild guild)
        {
            _guildBuilder.SwitchInstance(guild);
            this._guildBuilder.BuildVip(true);
            return _guildBuilder.GetInstance();
        }

        public Guild AddGuildMoney(Guild guild,double money)
        {
            _guildBuilder.SwitchInstance(guild);
            this._guildBuilder.AddMoney(money);
            return _guildBuilder.GetInstance();
        }

    }
}