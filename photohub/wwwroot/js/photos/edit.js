﻿const photosEdit = new Vue({
    el: '#photosEdit',
    data: {
        filter: document.querySelector('#container-filters').dataset.currentFilterName,
        currentPhotoId: document.querySelector('#photosEdit').dataset.currentPhotoId,
        tags: [],
        post: null,
        pickedTags: [],

        submited: false,
        metadataActive: false,
        addTagActive: false,
        message: {
            status: null,
            text: null
        },
    },
    created() {
        this.fetchPhoto();
        this.fetchTags();
    },
    mounted() {

    },
    methods: {
        fetchPhoto() {
            nanobar.go(40);
            this.$http.get(`/api/photos/details/${this.currentPhotoId}`).then(response => response.json()).then(json => {
                this.post = json;

                for (let i in json.tags)
                    this.pickedTags.push(json.tags[i].name);

                nanobar.go(100);
            },
            error => {
                nanobar.go(0);
                this.message.text = 'error while fetching photo';
                this.message.status = 'error';
            });
        },
        fetchTags() {
            this.$http.get(`/api/tags`).then(response => response.json()).then(json => {
                this.tags = json;
            },
            error => {
                this.message.text = 'error while fetching tags';
                this.message.status = 'error';
            });
        },
        pickFilter: function (f) {
            this.filter = f;
        },
        submit() {
            this.submited = true;
        },

        addTag(tagName) {
            if (!this.pickedTags.join().includes(tagName))
                this.pickedTags.push(tagName);

            this.closeAddTag();
        },
        removeTag(tagName) {
            for (let i in this.pickedTags) {
                if (this.pickedTags[i] == tagName)
                    this.pickedTags.splice(i, 1);
            }
        },

        showMetadata() {
            this.metadataActive = true;
        },
        closeMetadata() {
            this.metadataActive = false;
        },

        showAddTag() {
            this.addTagActive = true;
        },
        closeAddTag() {
            this.addTagActive = false;
        },
    }
});