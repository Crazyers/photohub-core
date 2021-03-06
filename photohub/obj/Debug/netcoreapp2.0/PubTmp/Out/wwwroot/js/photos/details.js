﻿const photosDetails = new Vue({
    el: '#photosDetails',
    data: {
        currentAppUserName: document.querySelector('#body').dataset.appUser,
        id: document.querySelector('#photosDetails').dataset.postId,

        post: null,

        commenting: false,
        message: {
            status: null,
            text: null
        },
        modals: {
            likeActive: false,
            optionActive: false
        }
    },
    created() {
        this.fetchPhoto();
    },
    mounted() {

    },
    methods: {
        fetchPhoto() {
            nanobar.go(40);

            this.$http.get(`/api/photos/details/${this.id}`).then(response => response.json()).then(json => {
                this.post = json;

                nanobar.go(100);
            },
            error => {
                nanobar.go(0);
                this.message.text = 'error while fetching photo';
                this.message.status = 'error';
            });
        },
        like() {
            if (!this.currentAppUserName)
                return -1;

            if (!this.post.liked) {
                this.post.liked = true;
                this.post.likes.push({
                    date: this.getCurrentDate(),
                    owner: {
                        userName: this.currentAppUserName
                    }
                });
                this.$http.post(`/api/likes/add/${this.id}`).then(response => {

                }, response => {
                    this.message.text = 'error while sending like';
                    this.message.status = 'error';

                    this.post.liked = false;
                    for (let i in this.post.likes) {
                        if (this.post.likes[i].owner.userName == this.currentAppUserName)
                            this.post.likes.splice(i, 1);
                    }
                });
            }
        },
        dislike() {
            if (!this.currentAppUserName)
                return -1;

            if (this.post.liked) {
                this.post.liked = false;
                for (let i in this.post.likes) {
                    if (this.post.likes[i].owner.userName == this.currentAppUserName)
                        this.post.likes.splice(i, 1);
                }
                this.$http.post(`/api/likes/delete/${this.id}`).then(response => {

                }, response => {
                    this.message.text = 'error while sending dislike';
                    this.message.status = 'error';

                    this.post.liked = true;
                    this.post.likes.push({
                        date: this.getCurrentDate(),
                        owner: {
                            userName: this.currentAppUserName
                        }
                    });
                });
            }

        },
        comment() {
            if (!this.currentAppUserName)
                return -1;

            const text = document.querySelector('#comment').value;

            if (text == '' || text.length < 1)
                return -1;

            this.commenting = true;
            nanobar.go(40);

            const words = text.split(/[, ;.]/);;

            let ok = true;

            for (let word in words) {
                if (words[word].length > 12)
                    ok = false;
            }

            if (ok) {
                this.$http.post(`/api/comments/add?photoId=${this.id}&text=${text}`).then(response => response.json()).then(json => {
                    this.post.comments.push({
                        $id: json,
                        text: text,
                        date: this.getCurrentDate(),
                        owner: {
                            userName: this.currentAppUserName
                        }
                    });

                    document.querySelector('#comment').value = '';
                    this.commenting = false;
                    nanobar.go(100);
                }, response => {
                    this.message.text = 'error while sending comment';
                    this.message.status = 'error';
                    this.commenting = false;
                    nanobar.go(100);
                });
            }
        },
        deleteComment(comment) {
            if (comment.owner.userName == this.currentAppUserName) {
                nanobar.go(60);
                this.$http.post(`/api/comments/delete/${comment.$id}`).then(response => {
                    for (let i in this.post.comments) {
                        if (this.post.comments[i].$id == comment.$id)
                            this.post.comments.splice(i, 1);
                    }
                    nanobar.go(100);
                }, response => {
                    nanobar.go(0);
                    this.message.text = 'error while deleting comment';
                    this.message.status = 'error';
                });
            }
        },

        modalLikes() {
            this.modals.likeActive = this.modals.likeActive?false:true;
        },
        modalOptions() {
            this.modals.optionActive = this.modals.optionActive ? false : true;
        },

        getCurrentDate() {
            const currentdate = new Date();
            const datetime = currentdate.getDay() + '-' + currentdate.getMonth() + '-' + currentdate.getFullYear() + " "
                + (currentdate.getHours() > 9 ? currentdate.getHours() : "0" + currentdate.getHours()) + ":" + (currentdate.getMinutes() > 9 ? currentdate.getMinutes() : "0" + currentdate.getMinutes());

            return datetime;
        }
    }
});