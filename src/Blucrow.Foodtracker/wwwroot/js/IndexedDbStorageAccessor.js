window.indexedDbHelper = {
    db: null,
    dbName: 'ftDb',
    storeName: 'ftdata',

    async openDatabase() {
        return new Promise((resolve, reject) => {
            if (this.db) {
                resolve(this.db);
                return;
            }

            const request = indexedDB.open(this.dbName, 1);

            request.onerror = (event) => {
                console.error("Database error:", event.target.errorCode);
                reject(`Database error: ${event.target.errorCode}`);
            };

            request.onsuccess = (event) => {
                this.db = event.target.result;
                resolve(this.db);
            };

            request.onupgradeneeded = (event) => {
                const db = event.target.result;
                if (!db.objectStoreNames.contains(this.storeName)) {
                    db.createObjectStore(this.storeName);
                    console.log('Object store created.');
                }
            };
        });
    },

    async addObject(key, value) {
        try {
            const db = await this.openDatabase();
            const transaction = db.transaction([this.storeName], 'readwrite');
            const store = transaction.objectStore(this.storeName);
            const request = store.put(value, key); // Store the JSON string

            return new Promise((resolve, reject) => {
                request.onsuccess = () => {
                    resolve(true);
                };
                request.onerror = (event) => {
                    console.error("Error adding object:", event.target.errorCode);
                    reject(`Error adding object: ${event.target.errorCode}`);
                };
            });
        } catch (error) {
            console.error("Error opening database:", error);
            return false;
        }
    },

    async getObject(key) {
        try {
            const db = await this.openDatabase();
            const transaction = db.transaction([this.storeName], 'readonly');
            const store = transaction.objectStore(this.storeName);
            const request = store.get(key);

            return new Promise((resolve, reject) => {
                request.onsuccess = () => {
                    resolve(request.result); // Parse the JSON string
                };
                request.onerror = (event) => {
                    console.error("Error getting object:", event.target.errorCode);
                    reject(`Error getting object: ${event.target.errorCode}`);
                };
            });
        } catch (error) {
            console.error("Error opening database:", error);
            return null;
        }
    },

    async getAllKeys() {
        try {
            const db = await this.openDatabase();
            const transaction = db.transaction([this.storeName], 'readonly');
            const store = transaction.objectStore(this.storeName);
            const request = store.getAllKeys();

            return new Promise((resolve, reject) => {
                request.onsuccess = () => {
                    resolve(request.result);
                };
                request.onerror = (event) => {
                    console.error("Error getting all keys:", event.target.errorCode);
                    reject(`Error getting all keys: ${event.target.errorCode}`);
                };
            });
        } catch (error) {
            console.error("Error opening database:", error);
            return [];
        }
    },

    async getAllObjects() {
        try {
            const db = await this.openDatabase();
            const transaction = db.transaction([this.storeName], 'readonly');
            const store = transaction.objectStore(this.storeName);
            const request = store.getAll();
            const keysRequest = store.getAllKeys();

            return Promise.all([
                new Promise((resolve, reject) => {
                    request.onsuccess = () => {
                        resolve(request.result ? request.result.map(item => JSON.parse(item)) : []); // Parse all JSON strings
                    };
                    request.onerror = (event) => {
                        console.error("Error getting all objects:", event.target.errorCode);
                        reject(`Error getting all objects: ${event.target.errorCode}`);
                    };
                }),
                new Promise((resolve, reject) => {
                    keysRequest.onsuccess = () => {
                        resolve(keysRequest.result);
                    };
                    keysRequest.onerror = (event) => {
                        console.error("Error getting all keys:", event.target.errorCode);
                        reject(`Error getting all keys: ${event.target.errorCode}`);
                    };
                })
            ]).then(([values, keys]) => {
                return keys.reduce((acc, key, index) => {
                    acc[key] = values[index];
                    return acc;
                }, {});
            });
        } catch (error) {
            console.error("Error opening database:", error);
            return {};
        }
    },

    async deleteObject(key) {
        try {
            const db = await this.openDatabase();
            const transaction = db.transaction([this.storeName], 'readwrite');
            const store = transaction.objectStore(this.storeName);
            const request = store.delete(key);

            return new Promise((resolve, reject) => {
                request.onsuccess = () => {
                    resolve(true);
                };
                request.onerror = (event) => {
                    console.error("Error deleting object:", event.target.errorCode);
                    reject(`Error deleting object: ${event.target.errorCode}`);
                };
            });
        } catch (error) {
            console.error("Error opening database:", error);
            return false;
        }
    }
};