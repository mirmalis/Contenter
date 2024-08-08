renewcerts:
	docker stop nginx
	sudo certbot renew

	sudo cp /etc/letsencrypt/live/api.sars.lt/cert.pem /mnt/configs/docker-composes/nginx/keys/api.sars.lt.public.pem
	sudo cp /etc/letsencrypt/live/sars.lt/cert.pem /mnt/configs/docker-composes/nginx/keys/sars.lt.public.pem
	sudo cp /etc/letsencrypt/live/sars.lt/privkey.pem /mnt/configs/docker-composes/nginx/keys/sars.lt.private.pem
	sudo cp /etc/letsencrypt/live/api.sars.lt/privkey.pem /mnt/configs/docker-composes/nginx/keys/api.sars.lt.private.pem

	docker compose up -d
