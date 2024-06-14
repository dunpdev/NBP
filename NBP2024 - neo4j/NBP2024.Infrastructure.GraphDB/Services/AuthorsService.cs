using NBP2024.Domain.Models;
using Neo4j.Driver;
using Neo4jClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBP2024.Infrastructure.GraphDB.Services
{
    public class AuthorsGraphDbContext
    {
        private readonly IGraphClient client;

        public AuthorsGraphDbContext(IGraphClient client)
        {
            this.client = client;
        }
        public async Task<IEnumerable<Author>> GetAuthorsAsync()
        {
            var query = client.Cypher
                .Match("(a: Author)")
                .Return(a => a.As<Author>());

            return (await query.ResultsAsync).ToList();
        }
        public async Task CreateAuthor(Author author)
        {
            var query = client.Cypher
                .Create("(a:Author $newAuthor)")
                .WithParam("newAuthor", author);

            await query.ExecuteWithoutResultsAsync();
        }
        public async Task AuthorTeachesCourse(int authorId, int courseId)
        {
            var query = client.Cypher
                .Match("(a:Author)", "(c:Course)")
                .Where((Author a) => a.Id == authorId)
                .AndWhere((Course c) => c.Id == courseId)
                .Create("(a)-[:TEACHES]->(c)");

            await query.ExecuteWithoutResultsAsync();
        }
    }
}
