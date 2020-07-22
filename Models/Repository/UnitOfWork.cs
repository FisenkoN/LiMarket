using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiMarket_V1._0._0.Models.Repository
{
    public class UnitOfWork : IDisposable
    {

        private MsContext _db = new MsContext();
        private EfRepository<Book> _bookRepository;
        private EfRepository<Author> _authorRepository;
        private EfRepository<Image> _imageRepository;
        private EfRepository<Genre> _genreRepository;

        public EfRepository<Book> Books
        {
            get
            {
                if (_bookRepository == null)
                    _bookRepository = new EfRepository<Book>();
                return _bookRepository;
            }
        }

        public EfRepository<Author> Authors
        {
            get
            {
                if (_authorRepository == null)
                    _authorRepository = new EfRepository<Author>();
                return _authorRepository;
            }
        }

        public EfRepository<Image> Images
        {
            get
            {
                if (_imageRepository == null)
                    _imageRepository = new EfRepository<Image>();
                return _imageRepository;
            }
        }

        public EfRepository<Genre> Genres
        {
            get
            {
                if (_genreRepository == null)
                    _genreRepository = new EfRepository<Genre>();
                return _genreRepository;
            }
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        private bool _disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
                this._disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}