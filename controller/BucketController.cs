using FreshFruit.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace FreshFruit.controller
{
    class BucketController
    {
        private Bucket bucket;
        private BucketEventListener eventListener;
        private Bucket keranjangBuah;
        private MainWindow mainWindow;

        public BucketController(Bucket bucket, BucketEventListener eventListener)
        {
            this.bucket = bucket;
            this.eventListener = eventListener;
        }

        public BucketController(Bucket keranjangBuah, MainWindow mainWindow)
        {
            this.keranjangBuah = keranjangBuah;
            this.mainWindow = mainWindow;
        }

        public void addFruit(Fruit fruit)
        {
            if (bucketIsOverload())
            {
                eventListener.onFailed("Ops, keranjang penuh");
            }
            else
            {
                this.bucket.insert(fruit);
                eventListener.onSucceed("Yey, berhasil ditambahkan");
            }
        }
        public bool bucketIsOverload()
        {
            return bucket.countItems() >= bucket.getCapacity();
        }

        public void removeFruit(Fruit fruit)
        {
            for (int itemPosition = 0; itemPosition < bucket.countItems(); itemPosition++)
            {
                if (bucket.findAll().ElementAt(itemPosition).getName() == fruit.name)
                {
                    bucket.remove(itemPosition);
                    eventListener.onSucceed("Yey, berhasil dihapus");
                }
            }
        }

        public List<Fruit> findAll()
        {
            return this.bucket.findAll();
        }

    }

}
