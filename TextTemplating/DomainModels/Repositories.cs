using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.Aggregates;

namespace kkkkkkaaaaaa.VisualStudio.TextTemplating.DomainModels
{
    /// <summary></summary>
    public class Repositories : TextTemplatingDomainModel<RepositoriesContext>
    {
        /// <summary>
        /// コンストラクター。
        /// </summary>
        /// <param name="context"></param>
        public Repositories(RepositoriesContext context) : base(context)
        {
            this.DoNothing();
        }


        public IEnumerable<RepositoriesContext> CreateRepositories()
        {
            var contexts = new Collection<RepositoriesContext>();

            var tables = this.Schema.GetTablesSchema();

            foreach (var table in tables)
            {
                var context = this.CreateRepository(table.TableName);
                contexts.Add(context);
            }

            return contexts;
        }

        private RepositoriesContext CreateRepository(string table)
        {
            this.Context.CurrentEntity = this.Context.Entities.First(entity => entity.TableName == table);
            this.Context.CurrentGateway = this.Context.Gateways.First(gateway => gateway.TableName == table);
            this.Context.TypeName = this.Context.TypeName.GetTypeName(table, this.Context.LetterCase);
            this.Context.FileName = this.Context.FileName.GetFileName(this.Context.TypeName);

            var template = new RepositoryTemplate(this.Context);
            var text = template.TransformText();

            if (!Directory.Exists(this.OutputPath)) { Directory.CreateDirectory(this.OutputPath); }
            var file = Path.Combine(this.OutputPath, this.Context.FileName.ToString());
            this.Flush(file, text);

            var context = KandaDataMapper.MapToObject<RepositoriesContext>(this.Context);

            return context;
        }


        public async Task<IEnumerable<RepositoriesContext>> CreateRepositoriesAsync()
        {
            var repositories = new Collection<RepositoriesContext>();

            var tables = this.Schema.GetTablesSchema();

            //await this.Context.Gateways
            await tables
                .ToAsyncEnumerable()
                .ForEachAsync(async gateway =>
                {
                    var repository = await this.CreateRepositoryAsync(gateway.TableName);
                    repositories.Add(repository);
                });

            return repositories;
        }

        public async Task<RepositoriesContext> CreateRepositoryAsync(string gateway)
        {
            this.Context.CurrentGateway = new TableDataGatewaysContext { TableName = gateway, };
            // this.Context.CurrentGateway = this.Context.Gateways.First(g => g.TableName == gateway);
            this.Context.CurrentEntity = this.Context.Entities.First(entity => entity.TableName == gateway);
            this.Context.TypeName = this.Context.TypeName.GetTypeName(this.Context.CurrentGateway.TableName);
            this.Context.FileName = this.Context.FileName.GetFileName(this.Context.TypeName);
            
            var template = new RepositoryTemplate(this.Context);
            var text = template.TransformText();

            if (!Directory.Exists(this.OutputPath)) { Directory.CreateDirectory(this.OutputPath); }
            var file = Path.Combine(this.OutputPath, this.Context.FileName.ToString());
            await this.FlushAsync(file, text);

            var context = KandaDataMapper.MapToObject<RepositoriesContext>(this.Context);

            return context;
        }
    }
}
