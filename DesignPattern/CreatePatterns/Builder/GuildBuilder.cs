namespace DesignPattern.CreatePatterns.Builder
{
    public class GuildBuilder
    {
        private Guild _guild { get; set; }
        public GuildBuilder()
        {
            _guild = new Guild();
        }
        public void BuildName(string Name)
        {
            _guild.Name = Name;
        }
        public void BuildVip(bool isVip)
        {
            _guild.IsVip = isVip;
        }
        public void BuildJoinAudit(bool JoinAudit)
        {
            _guild.JoinAudit = JoinAudit;
        }
        public void AddMoney(double money)
        {
            _guild.Money += money;
        }
        public Guild GetInstance() => this._guild;
        public Guild ReInitInstance() => _guild = new Guild();
        public void SwitchInstance(Guild guild) => this._guild = guild;
    }
}