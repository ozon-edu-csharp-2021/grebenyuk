using FluentMigrator;

namespace OzonEdu.MerchandiseService.Migrator.Migrations
{
    [Migration(1)]
    public class Tickets : Migration
    {
        public override void Up()
        {
            Execute.Sql(@"                
                create table if not exists tickets
                (
                  id bigserial
                    constraint tickets_pk
                      primary key,
                  employee_id bigint not null,
                  sku bigint not null,
                  status int not null,
                  created_at timestamp default timezone('utc'::text, now()) not null,
                  updated_at timestamp default timezone('utc'::text, now())
                );"
            );
        }

        public override void Down()
        {
            Execute.Sql("drop table if exists tickets;");
        }
    }
}