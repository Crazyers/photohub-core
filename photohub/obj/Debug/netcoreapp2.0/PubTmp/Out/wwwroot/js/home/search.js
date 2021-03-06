﻿const search = new Vue({
    el: '#search',
    data: {
        currentAppUserName: document.querySelector('#body').dataset.appUser,
        users: null,
        searchString: '',

        usersLoaded: false,
        incallback: false,
        page: 0,
    },
    mounted() {
        window.addEventListener('scroll', this.autoSearch);
    },
    created() {
        this.search();
    },
    methods: {
        search() {
            if (!this.incallback && this.page > -1) {

                this.incallback = true;
                nanobar.go(40);

                this.$http.get(`/api/users/search?search=${this.searchString}&page=${this.page}`).then(response => response.json()).then(json => {

                    if (this.users == null)
                        this.users = json;
                    else if (json.length == 0)
                        this.usersLoaded = true;
                    else {
                        for (let user in json)
                            this.users.push(json[user]);
                    }

                    nanobar.go(100);
                    this.incallback = false;
                    this.page++;
                },
                error => {
                    nanobar.go(0);
                    this.incallback = false;
                    this.message.text = 'error while fetching users';
                    this.message.status = 'error';
                });
            }
        },
        autoSearch() {
            if (!this.postsLoaded && this.users.length % 12 == 0 && document.documentElement.scrollTop == document.documentElement.scrollHeight - window.innerHeight)
                this.search();
        },
        handleSearch(str) {
            if (this.searchString.length > 2 || !this.searchString.length) {
                this.users = null;
                this.page = 0;
                this.search();
            }
        },

        follow(user) {
            if (!this.currentAppUserName)
                return -1;

            if (!user.followed) {
                user.followed = true;
                this.$http.post(`/api/users/follow/${user.userName}`).then(response => {

                }, response => {
                    this.message.text = 'error while following';
                    this.message.status = 'error';

                    user.followed = false;
                });
            }
        },
        disfollow(user) {
            if (!this.currentAppUserName)
                return -1;

            if (user.followed) {
                user.followed = false;

                this.$http.post(`/api/users/dismiss/follow/${user.userName}`).then(response => {

                }, response => {
                    this.message.text = 'error while disfollowing';
                    this.message.status = 'error';

                    user.followed = true;
                });
            }
        }
    }
});